# BlueprintManager
From The Depthのblueprintファイル管理ツール。バックアップがメイン。

## 配布場所
https://github.com/tvagames/BlueprintManager/releases

## 使い方
### 初回
1. バックアップフォルダをどこかに作っておく
2. targetにBPフォルダを設定する
3. backupに1で作ったフォルダを設定する
4. start at startup のチェックをONにする
5. startボタンを押す
6. 左部のツリーで一番上を選択して右クリック→Backup

### 2回目以降
1. 起動するだけ

## 機能詳細
### target設定
targetにFtDのblueprintファイルを格納しているフォルダを指定してください。

例)
> C:\Documents\From The Depths\Player Profiles\[プレイヤー名]\Constructables

### backup設定
backupにblueprintファイルをコピーするバックアップフォルダを指定してください。
バックアップフォルダはあらかじめ作っておいてください。

### start at startupにチェックON
本ツール起動時に、自動的にstartするか否か。

### start
targetフォルダの監視を開始します。

### stop
targetフォルダの監視を停止します。
監視していない場合、blueprintファイルに変更があっても無視します。

### タスクバー
タスクバーのアイコンからstart、stop、exit（終了）ができます。

### リストア
右下のリストで右クリックし、restoreを実行すればそのバージョンに戻ります。

FTDクライアントの再起動は不要。
ただし、再起動するまで（？）FTD上のバージョン表記はリストア前のままです。

### 自動起動
OSのスタートアップに入れておくと良いかも

## 注意点
* 自己責任でお願いします。
* バックアップファイルやフォルダは自動削除していないので、超重戦艦を毎秒保存とかやると容量がガリガリ減っていくかも。気になるようなら手動削除で。


