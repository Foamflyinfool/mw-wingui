MultiWii WinGUI is a .NET based configuration and GCS interface for the famous MultiWii multicopter controller software.

It does not intend to replace the original MultiWiiConf utility, but trying to offer a richer user experience by sacrificing multi platform capabilities.

# Installation #
You find the install files at http://code.google.com/p/mw-wingui/downloads/list
The WinGUI  needs .NET2.0 and .NET4 frameworks, plus a VSC++2008 runtime to run correctly (Aforge video libs are for .net2.0, and FFMPG library is using VSC runtime) On an average Win7 installation these components are already installed. If not, you can find the installers at the downloads section on googlecode. If you don’t trust those downloads then you can get the components from the following links :

Visual C++ 2008 redistributable library
http://www.microsoft.com/download/en/confirmation.aspx?id=5582

.NET framework 2.0
http://www.microsoft.com/download/en/confirmation.aspx?id=19

.NET framework 4 Client profile
http://www.microsoft.com/download/en/details.aspx?id=24872

To install WinGUI just extract it to a folder and run MultiWiiWinGUI.exe. The settings wizard should start. If you got an error message at start or when closing, it usually means that some of the three components mentioned above is not installed.
---
# Usage tips #
## Artificial Horizon indicator seems to be wrong, when plane rolls left it tilts right. ##
Well, this is how artificial horizons are working. Imagine that you are sitting it a plane, if you roll left with the plane the horizon will tilt right. You can try it at home, tilt your head left and see how the horizon is tilting… :D

Now if you prefer, you can change the artifical horizon indicator to a MultiWiiConf style roll/pitch indicator. Just click on the control.

## Zooming and panning in the graph ##
You can zoom in the graph with your mouse scrollwheel. The graph panel also right click enabled, you can restore view or save a capture of the graph. You can pan in the graph while hold down SHIFT.

# Donate #
I'm working on this project in my spare time. If you find it usefull and you think that you can support my efforts, then please click on the button below... :D

[![](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=GNCWUBYAGA35L&lc=HU&item_name=Andras%20Schaffer&currency_code=EUR&bn=PP%2dDonationsBF%3abtn_donate_LG%2egif%3aNonHosted)