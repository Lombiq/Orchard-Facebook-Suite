# Facebook Suite Orchard module Readme



## Project Description

The Facebook Suite module enriches Orchard sites with Facebook-related functionality. Features include authentication with Facebook and social plugins.


## Features

- Loads the Facebook JS SDK with app configurations
- Exposes FacebookClient from FB C# SDK through service
- Facebook Connect authentication with Facebook Suite Connect module:
	- Simple (user only has to provide a username) or full registration (user registers as normally, but can login with one click)
	- Optional requirement of verified FB account
	- Registered users can attach their account to their FB account for simple login
	- Profile pictures are saved as avatars
	- Link to FB profile on user profiles
	- User data saved and exposed through service with other features
	- Import/export configuration
- Comments box widget
- Like button widget
- Facepile widget
- Like box widget
- Import/export configuration

The module can be installed from the Orchard admin panel by searching for "Facebook Suite" or can be downloaded from the [Orchard gallery](http://gallery.orchardproject.net/List/Modules/Orchard.Module.Piedone.Facebook.Suite).

**Please make sure to read the [Documentation](Docs/Documentation.md)!**

The module's source is available in two public source repositories, automatically mirrored in both directions with [Git-hg Mirror](https://githgmirror.com):

- [https://bitbucket.org/Lombiq/orchard-facebook-suite](https://bitbucket.org/Lombiq/orchard-facebook-suite) (Mercurial repository)
- [https://github.com/Lombiq/Orchard-Facebook-Suite](https://github.com/Lombiq/Orchard-Facebook-Suite) (Git repository)

Bug reports, feature requests and comments are warmly welcome, **please do so via GitHub**.
Feel free to send pull requests too, no matter which source repository you choose for this purpose.

This project is developed by [Lombiq Technologies Ltd](http://lombiq.com/). Commercial-grade support is available through Lombiq.