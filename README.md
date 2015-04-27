# suavebootstrapper

1) run `build.cmd` and it will
  * download latest paket.exe
  * download all packages from paket.dependencies:
      * FAKE (which is like an fsi)
      * suave
      * FSharp.Data, FSharp.Charting (for the mini sample)
  * it starts FAKE:
  * and FAKE starts suave at port 8083
 
or 

2) run `build.cmd port=1000` to do the same on port 1000
  
