MAXI COAST RUSH - XBOX PACKAGING GUIDE
=======================================
This folder contains everything needed to produce the .msix for
side-loading on Xbox (Developer Mode). The packaging step itself must
run on a Windows machine (Microsoft's packaging/signing tools are
Windows-only). Two routes - Route A is simplest.

STEP 0 - ONE-TIME, BOTH ROUTES: MAKE THE GAME FULLY OFFLINE
  On any machine with internet, open a terminal in MaxiCoastRush/GameFiles
  and run ONE of:
      powershell -ExecutionPolicy Bypass -File download-assets.ps1   (Windows)
      bash download-assets.sh                                        (Mac/Linux)
  This mirrors the painted textures + sound effects into assets/cdn/.
  After this the game makes ZERO network requests. (If you skip it, the
  game still runs offline but with simpler procedural art and no SFX.)

ROUTE A - PWABuilder (no Visual Studio, ~15 minutes)
  1. Host the GameFiles folder on any HTTPS server (or run locally with
     a tunnel). It is already a valid PWA (manifest + service worker).
  2. Go to https://www.pwabuilder.com , enter the URL, click through to
     "Package for Stores" -> Windows. Download the generated .msix.
  3. Skip to SIDELOADING below.

ROUTE B - Visual Studio wrapper (this project, full control)
  1. On Windows, install Visual Studio 2022 with the ".NET desktop
     development" and "Windows application development" workloads.
  2. Open MaxiCoastRush/MaxiCoastRush.csproj.
  3. Right-click project -> Publish -> Create App Packages ->
     Sideloading -> create a self-signed test certificate when prompted
     -> choose x64 (Xbox Series consoles are x64) -> Create.
  4. Output lands in AppPackages/ as .msix (+ the .cer certificate).

WHAT THE WRAPPER DOES (already configured)
  * Borderless strict fullscreen window, no browser UI whatsoever.
  * WebView2 serves the game from the packaged GameFiles via a virtual
    host (https://app.local/) - 100% local, no internet needed.
  * Context menus / devtools / zoom / status bar disabled.
  * Xbox controllers reach the game through the standard HTML5 Gamepad
    API (the game polls navigator.getGamepads directly - no virtual
    mouse involved). Both pads work; A joins, stick steers, RT gas.

SIDELOADING ON THE XBOX
  1. Console: enable Developer Mode (Dev Mode activation app, one-time
     $19 partner account if not already active).
  2. In Dev Home note the console's IP; open https://<xbox-ip>:11443
     (Xbox Device Portal) from your PC; pair with the on-screen PIN.
  3. Device Portal -> Add -> upload the .msix (and the .cer if asked,
     or install the .cer on the console via "Install certificate").
  4. Launch "Maxi Coast Rush" from Dev Home. In Dev Mode settings set
     the app type to "Game" for full resources (important for 60fps
     split-screen).

BOOTH-DAY CHECKLIST
  [] download-assets script was run (assets/cdn/ has 14 files)
  [] App type set to "Game" in Dev Home
  [] Two controllers paired and tested in the lobby
  [] Sound check: press any key/tap once after boot if audio is muted
     (browser engines require one user gesture before audio)
  [] Console set to never sleep during the event
