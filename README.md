# csharp

## 環境

### .NET

```console
PS> dotnet --info
.NET SDK:
 Version:           9.0.302
 Commit:            bb2550b9af
 Workload version:  9.0.300-manifests.fadeff71
 MSBuild version:   17.14.13+65391c53b

ランタイム環境:
 OS Name:     Windows
 OS Version:  10.0.26100
 OS Platform: Windows
 RID:         win-x64
 Base Path:   C:\Program Files\dotnet\sdk\9.0.302\

インストール済みの .NET ワークロード:
表示するインストール済みワークロードはありません。
新しいマニフェストをインストールするときに loose manifests を使用するように構成されています。

Host:
  Version:      9.0.7
  Architecture: x64
  Commit:       3c298d9f00

.NET SDKs installed:
  9.0.302 [C:\Program Files\dotnet\sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 9.0.7 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 9.0.7 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.WindowsDesktop.App 9.0.7 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]

Other architectures found:
  None

Environment variables:
  Not set

global.json file:
  Not found

Learn more:
  https://aka.ms/dotnet/info

Download .NET:
  https://aka.ms/dotnet/download
```

## プロジェクトの作り方

### コンソールデモ

```console
dotnet new console -n <your-package-name>
```

### クラスライブラリ

```console
dotnet new classlib -n <your-package-name>
```

### slnへに追加

IntelliSenseを有効化するのに必要

```console
dotnet sln csharp.sln add StdExt/StdExt.csproj
```
