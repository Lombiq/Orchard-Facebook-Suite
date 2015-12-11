# Facebook Suite Orchard module Documentation



**Note that all current versions of Facebook Suite and Facebook Suite Connect require Orchard 1.4 or greater!**


## Important update notes

### Update notes from FB Suite v1.2.1 and FB Suite Connect 1.0.3

With version 6 the [Facebook C# SDK](http://csharpsdk.org/) that's included in the [Facebook SDK](https://gallery.orchardproject.net/List/Modules/Orchard.Module.FacebookSDK) module was deeply modified with plenty of breaking changes. Facebook Suite as well as Facebook Suite Connect was rewritten to adapt to the changes in the SDK, but this has two consequences:

- Facebook Suite and Facebook Suite Connect both have breaking changes on the API level (if you don't use the services included in the modules when developing your own modules you don't have to bother with this).
- When updating the modules you have to update Facebook SDK as well. **Facebook Suite 1.3 or greater and Facebook Suite Connect 1.1 or greater require the Facebook SDK module 1.2 (or greater)!**

All in all, if you want to use Facebook Suite 1.3 or Facebook Suite Connect 1.1 you have to do the following:

1. Disable all the Facebook Suite modules (practically this happens if you disable Facebook SDK)
2. Update Facebook SDK
3. Update Facebook Suite (If you have Facebook Suite Connect installed, you'll get exceptions here about assembly references. This is "normal" but you could avoid it if you delete the Facebook Suite Connect module folder first.)
4. Update Facebook Suite Connect if you use it
5. You may have to repeatedly hit refresh on your site if some UI elements get missing (e.g. the search box under Features, don't ask why...)

**Note that Facebook Suite Connect does not include the problematic auto-login feature anymore.**

### Update notes from v1.1

**Please read carefully!**
Beginning from v1.2 of Facebook Suite the parts responsible for social plugin widgets are no longer attachable! That means if you've used those widget parts attached to content items, you have to do the following:

1. Remove the parts from all content types on the admin site. If you have any important configuration saved, write it down.
2. Update Facebook Suite.
3. After the migrations are run, you're clean to use the [Content Widgets](https://github.com/Lombiq/Orchard-Content-Widgets) module to attach any widget to content types. Use that to achieve what was previously, only more comfortable: now widgets will require configuration only once, not with every item.

### Update notes for Connect from v0.9

Version 1.0 changes the behavior in that FB Connect configuration takes place on per-site level (not per-widget level). This is actually the sane way, since the previous setup made it possible to authenticate with different settings (e.g. different FB permissions) for the same site. Thus, configuration moved to the Facebook Suite Settings under the Settings menu.  
Another change is that the module is no longer dependent on the Helpful Libraries module.  
**Note that since 1.0 Facebook Suite Connect requires Orchard 1.4!**

### Update instructions from versions 0.9.1.5 or earlier

**Please read these instructions carefully if you update from such versions! There are also breaking changes!**  
Although the update is made as seamless as possible, since **the Facebook Connect feature was split into a new module, Facebook Suite Connect** (to avoid a big number of dependencies for the whole Facebook Suite), it's not trivial.

1. First make sure you're running Facebook Suite 0.9.1.5. If not, update the module to this version.
2. Disable all Facebook Suite features, just in case.
3. Disable the Service Validation Libraries feature. You can also safely remove this module's folder (Piedone.ServiceValidaton) from the Modules directory, as Facebook Suite (and any other modules developed by me) no longer depends on it (however there could be other 3rd party modules depending on it, who knows, check it first). However the Facebook Suite Connect modules needs its successor, Helpful Libraries. More on that later.
4. Since the [Facebook SDK](https://gallery.orchardproject.net/List/Modules/Orchard.Module.FacebookSDK) module (which contains the [Facebook C# SDK](http://facebooksdk.net/)) that Facebook Suite depends on was updated as well, please update it first.
5. Update Facebook Suite. Now you can also re-enable all features you wish. **The following steps are only needed if you used or plan to use the Facebook Connect feature.**
6. Install the [Helpful Libraries](https://gallery.orchardproject.net/List/Modules/Orchard.Module.Piedone.HelpfulLibraries) module, as the new Facebook Suite Connect module depends on it.
7. Install the [Avatars](https://gallery.orchardproject.net/List/Modules/Orchard.Module.Piedone.Avatars) module, as Facebook Connect needs it for improved profile picture handling. Please read the the [Avatars module's docs](https://github.com/Lombiq/Orchard-Avatars) too, as it also has dependencies.
8. Install the [Facebook Suite Connect](https://gallery.orchardproject.net/List/Modules/Orchard.Module.Piedone.Facebook.Suite.Connect) module.
9. Now you can enable it. When prompted to upgrade, upgrade the module. This will do the necessary modifications to the database.

**Please note that css classes have also changed, as well as the stylesheet's name!**


## How many modules are there?

Although being logically part of the same package, Facebook Suite consists of two modules:

- [Facebook Suite](http://gallery.orchardproject.net/List/Modules/Orchard.Module.Piedone.Facebook.Suite): this is the base of Facebook Suite, including social plugin widgets
- [Facebook Suite Connect](https://gallery.orchardproject.net/List/Modules/Orchard.Module.Piedone.Facebook.Suite.Connect): not to accumulate too much dependencies for one module, the Facebook Connect feature of Facebook Suite is published in a separate module. This module depends on Facebook Suite.

**See the [Facebook Suite Connect module documentation](FacebookSuiteConnectDocumentation.md)**


## For developers

For how you can use Facebook Suite's services in you own module, take a look at the IFacebookSuiteService and IFacebookConnectService interfaces and their inline documentation. To use them just add the module's project as a reference in your on module and inject the implementation of these interfaces in the constructor just as any other Orchard service.

## Installation

The module depends on [Facebook SDK](https://github.com/Lombiq/Orchard-Facebook-SDK). Please install it prior to installing the module!
After installing the module and enabling the features you'll get a bunch of new widgets. This way, the individual social plugins can be used as widgets.
If you want to use these widgets attached to content types, take a look at [Content Widgets](https://github.com/Lombiq/Orchard-Content-Widgets).

**See the [Version history](VersionHistory.md)**