BUILD THE .MSIX WITHOUT VISUAL STUDIO (GitHub does it for you)
===============================================================
One-time setup, ~10 minutes, free:

1. Create a free account at github.com if you don't have one, then a
   new PRIVATE repository (e.g. "maxi-xbox").
2. Upload THIS ENTIRE FOLDER's contents to the repo (drag-and-drop on
   github.com works: Add file -> Upload files). Make sure the folder
   structure is kept: MaxiCoastRush/... and .github/workflows/...
   IMPORTANT: run download-assets.ps1 (or .sh) inside
   MaxiCoastRush/GameFiles BEFORE uploading, so the package is
   fully offline.
3. In the repo: Actions tab -> "Build Xbox MSIX" -> Run workflow.
   (It also runs automatically on every push.)
4. Wait ~5-8 minutes. Open the finished run -> Artifacts ->
   download "xbox-package". Inside:
      MaxiCoastRush_1.0.0.0_x64.msix   <- the app
      MaxiBooth.cer                    <- the certificate
5. Xbox Device Portal (https://<xbox-ip>:11443):
   - install MaxiBooth.cer first (or add it when prompted),
   - Add -> deploy the .msix,
   - Dev Home -> set app type to "Game".

The workflow builds Release x64, signs with a self-signed cert
(password "booth" - only used inside the build), and never publishes
anything anywhere; artifacts are visible only to you.
