# Facebook Suite Connect Orchard module Documentation



## Installation

**The module depends on Facebook Suite, [Helpful Libraries](https://gallery.orchardproject.net/List/Modules/Orchard.Module.Piedone.HelpfulLibraries) (at least 1.6) and [Avatars](https://gallery.orchardproject.net/List/Modules/Orchard.Module.Piedone.Avatars). Please install them prior to installing the module!**  
Note that the feature will only work if you set up an application on Facebook and provide its details under the Facebook Suite Settings page under Settings.  

### Update notes for Connect from v0.9

Version 1.0 changes the behavior in that FB Connect configuration takes place on per-site level (not per-widget level). This is actually the sane way, since the previous setup made it possible to authenticate with different settings (e.g. different FB permissions) for the same site. Thus, configuration moved to the Facebook Suite Settings under the Settings menu.  
Another change is that the module is no longer dependent on the Helpful Libraries module.  
**Note that since 1.0 Facebook Suite Connect requires Orchard 1.4!**


## Usage

Set up the configuration in under Facebook Suite Settings in site settings, then place a Facebook Connect widget (or multiple) widgets on your page. If you place the widget on a layer that both authenticated and non-authenticated users can see then not besides non-authenticated users being able to log in through Facebook, authenticated ones can attach their Facebook account to their local one for one-click sign in.  
If you choose to only allow verified Facebook users to register, make sure to warn your visitors somehow beforehand.  
After an unsuccessful login attempt the module adds error messages to the notification system. However notifications are not always displayed, depending on the theme. Typically notifications are not displayed on the home page, so if a user attempts to log in from the home page but is rejected, she/he won't see the messages. Please make sure to inspect your theme.


## Otherwise non-documented features

- Users' profile pictures are saved as avatars
- If the users' profile is displayed (e.g. with Contrib.Profile module) there will be a link to their FB profile displayed