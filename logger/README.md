# loggerプロジェクト

spdlog的な物を簡単に作ってみる試み。

## 採用ライブラリ

- Serilog
- Microsoft.Extensions.Logging

## パッケージ

```console
dotnet add package Microsoft.Extensions.Logging
dotnet add package Serilog
dotnet add package Serilog.Extensions.Logging
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
dotnet add package Serilog.Formatting.Compact
dotnet add package Serilog.Enrichers.WithCaller
dotnet add package Serilog.Enrichers.SourceContext
```

`logger.csproj`に以下の設定が追加された。

```xml
  <ItemGroup>
    <PackageReference Include="Serilog.Extensions.Logging" Version="9.0.2" />
    <PackageReference Include="Serilog.Sinks.Console" Version="6.0.0" />
  </ItemGroup>
```

## 使用方法

### ビルド

```console
dotnet build
```
