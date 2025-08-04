# 標準拡張ライブラリ　テストプロジェクト

## プロジェクトの作り方

```console
$ dotnet new xunit -n StdExt.Tests
$ cd StdExt.Tests
$ dotnet add reference ../StdExt/StdExt.csproj
```

## 使い方

### ビルド方法

```console
$ dotnet build
```

### 実行方法

```console
$ dotnet test
```

```console
$ dotnet test --logger "console;verbosity=detailed"
```
