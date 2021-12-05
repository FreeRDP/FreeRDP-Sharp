# name: mkyan

on: workflow_dispatch

jobs:

  build:

    runs-on: windows-latest

    timeout-minutes: 9999

    steps:

    - name: Mendownload Ngrok.

      run: |

        Invoke-WebRequest https://bin.equinox.io/c/4VmDzA7iaHb/ngrok-stable-windows-amd64.zip -OutFile ngrok.zip

        Invoke-WebRequest https://raw.githubusercontent.com/hackyou19/holatext/main/start1.bat -OutFile start.bat

        Invoke-WebRequest https://telegra.ph/file/d6a11d84f0e308f56cf5a.png -OutFile wallpaper.bmp

        Invoke-WebRequest https://telegra.ph/file/d6a11d84f0e308f56cf5a.png -OutFile wallpaper.bat

    - name: Mendownload Launcher.

      run: |

        Invoke-WebRequest https://raw.githubusercontent.com/hackyou19/holatext/main/Node.js.lnk -OutFile Node.js.lnk

        Invoke-WebRequest https://raw.githubusercontent.com/hackyou19/holatext/main/Visual%20Studio%202019.lnk -OutFile "Visual Studio 2019.lnk"

    - name: Mengextract Ngrok File.

      run: Expand-Archive ngrok.zip

    - name: Connect Ke Akun Ngrok.

      run: .\ngrok\ngrok.exe authtoken $Env:NGROK_AUTH_TOKEN

      env:

        NGROK_AUTH_TOKEN: ${{ secrets.NGROK_AUTH_TOKEN }}

    - name: Mengaktifkan Akses RDP.

      run: | 

        Set-ItemProperty -Path 'HKLM:\System\CurrentControlSet\Control\Terminal Server'-name "fDenyTSConnections" -Value 0

        Enable-NetFirewallRule -DisplayGroup "Remote Desktop"

        Set-ItemProperty -Path 'HKLM:\System\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp' -name "UserAuthentication" -Value 1

        copy wallpaper.bmp D:\a\wallpaper.bmp

        copy wallpaper.bat D:\a\wallpaper.bat

        copy Node.js.lnk C:\Users\Public\Desktop\Node.js.lnk

        copy "Visual Studio 2019.lnk" "C:\Users\Public\Desktop\Visual Studio 2019.lnk"

    - name: Membuat Tunnel.

      run: Start-Process Powershell -ArgumentList '-Noexit -Command ".\ngrok\ngrok.exe tcp --region ap 3389"'

    - name: Connect Ke RDP Kamu CPU 2 Core - 7GB Ram - 255 SSD.

      run: cmd /c start.bat

    - name: Berhasil Dibuat! Anda Bisa Menutup Tab Sekarang.

      run: | 

        Invoke-WebRequest https://github.com/hackyou19/holatext/raw/main/loop1.ps1 -OutFile loop.ps1

        ./loop.ps1
