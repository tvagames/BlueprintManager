using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintManager
{
    class BackupManager
    {
        private System.IO.FileSystemWatcher watcher = new FileSystemWatcher();
        public string BackupPath { get; set; }
        public string TargetPath { get; set; }

        public event FileSystemEventHandler FileChanged;
        public event FileSystemEventHandler FileCreated;
        public event FileSystemEventHandler FileDeleted;
        public event RenamedEventHandler FileRenamed;
        public event EventHandler Backuped;

        internal void Start(string text1, string text2)
        {
            TargetPath = text1;
            BackupPath = text2;
            
            watcher.Path = text1;
            watcher.Filter = "*.blueprint";
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = System.IO.NotifyFilters.FileName |
                                    System.IO.NotifyFilters.DirectoryName |
                                    System.IO.NotifyFilters.LastWrite;
            //イベントハンドラの追加
            watcher.Changed += new System.IO.FileSystemEventHandler(watcher_Changed);
            watcher.Created += new System.IO.FileSystemEventHandler(watcher_Created);
            watcher.Deleted += new System.IO.FileSystemEventHandler(watcher_Deleted);
            watcher.Renamed += new System.IO.RenamedEventHandler(watcher_Renamed);

            //監視を開始する
            watcher.EnableRaisingEvents = true;
        }

        private void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            this.BackupFile(e);
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            this.BackupFile(e);

        }

        private void BackupFile(FileSystemEventArgs e)
        {
            this.BackupFile(e.FullPath);
        }

        public void BackupFile(string filePath)
        {
            var file = new FileInfo(filePath);
            var related = filePath.Substring(this.TargetPath.Length);
            related = related.Substring(0, related.Length - file.Name.Length);

            var fileNameWithoutExt = file.Name.Substring(0, file.Name.Length - file.Extension.Length);
            var backupFolder = this.BackupPath + related + fileNameWithoutExt;
            var backupFolderInfo = new DirectoryInfo(backupFolder);
            if (!backupFolderInfo.Exists)
            {
                backupFolderInfo.Create();
            }

            var backupFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".backup";
            var backupFilePath = Path.Combine(backupFolder, backupFileName);

            bool queueAdded = false;
            lock (queue)
            {
                if (!queue.ContainsKey(filePath))
                {
                    queue.Add(filePath, backupFilePath);
                    queueAdded = true;
                }
            }
            if (queueAdded)
            {
                System.Threading.Tasks.Task.Delay(1000).ContinueWith(_ => {
                    var succeed = false;
                    var retry = 0;
                    var f = new FileInfo(filePath);
                    while (succeed == false && retry < 10)
                    {
                        try
                        {
                            System.IO.File.Copy(filePath, backupFilePath);
                            succeed = true;
                        }
                        catch (Exception)
                        {
                            System.Threading.Thread.Sleep(1000);
                            retry++;
                        }
                    }
                    lock (queue)
                    {
                        queue.Remove(filePath);
                        if (this.Backuped != null)
                        {
                            this.Backuped(this, new EventArgs());
                        }
                    }
                });

            }

        }

        public void RestoreFile(string filePath)
        {
            var backupFile = new FileInfo(filePath);
            var blueprintName = backupFile.Directory.Name + ".blueprint";
            var related = filePath.Substring(this.BackupPath.Length);
            related = related.Substring(0, related.Length - backupFile.Name.Length - backupFile.Directory.Name.Length - 1);
            var target = this.TargetPath + related + blueprintName;
            File.Copy(filePath, target, true);
        }

        private Dictionary<string, string> queue = new Dictionary<string, string>();

        internal void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }
    }
}

