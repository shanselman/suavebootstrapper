@echo off
cls

mkdir .paket
curl https://github.com/fsprojects/Paket/releases/download/1.2.0/paket.bootstrapper.exe -L --insecure -o .paket\paket.bootstrapper.exe

.paket\paket.bootstrapper.exe prerelease
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

REM Azure will start this
REM packages\FAKE\tools\FAKE.exe build.fsx %*
