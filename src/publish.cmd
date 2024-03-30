rem dotnet publish SteelRazor --configuration Release --output SteelRazor-app --self-contained
rem dotnet publish SteelRazor --configuration Release --output SteelRazor-app-single --self-contained /p:PublishSingleFile=true
dotnet publish SteelRazor --configuration Release --output SteelRazor-app-aot-win-x64 --runtime win-x64 /p:PublishAot=true

PAUSE