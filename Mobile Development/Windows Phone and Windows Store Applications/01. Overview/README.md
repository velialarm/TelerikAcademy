<p align="center"><a href="http://academy.telerik.com/">
<img src="https://raw.githubusercontent.com/velialarm/TelerikAcademy/master/telerik-academy.png" /></a></p>

# Overview

* What is Windows Universal?
* History
* Concepts
* Windows Run Time – WinRT
    * XAML + C#
    * HTML + JS (WinJS)
* Requirements – needed software

###History of Windows Universal 
* 2010 – Windows Phone 7
* Mid-2011 – public beta of  Windows 8
* Mid-2012 – publicly released Windows 8
    * Designed for touch
    * Microsoft’s OS was headed for the tablet
* April 2014 – Windows Universal Apps 
    * Convergence of Windows 8.1 and WP 8.1
    * Create applications that target the phone and tablet and share a single code base

###Windows Universal Concept
* Develop a universal Windows app that targets Windows and Windows Phone
    * Share: code, user controls, styles, strings, and other assets between the two projects
    * Linked files between projects
    * Conditional compilation with preprocessor directives
~~~
#if WINDOWS_APP
  //run Windows specific code
#elif WINDOWS_PHONE_APP
  //run Windows Phone specific code
#endif
~~~
###WinRT
* Use XAML + C# or HTML and JS
* WinRT APIs (the Windows namespace)
    * Application model
        * Activation, suspension, viewStates, etc.
    * File storage, Application file system access
        * File & Folder pickers, roaming data, settings, etc.
    * Contracts, Extensions
    * Devices
        * Geolocation, Sensors, Cameras, Speakers, etc.
    * Networking, Security, Notifications, etc.
    * Basically gives you access to all Windows 8 APIs

###XAML + C#
* Descendant of Silverlight
* Developing apps using XML-based declarative language
    * Powerful built-in data and behavior binding
    * Full set of UI components
    * Easy-to-learn and adapt
    * Model-View-ViewModel architecture that is easy to follow

###(HTML + JS) WinJS
* Use HTML + CSS & JavaScript
* Fully-featured JavaScript library
    * DOM queries
    * Pages and Navigation
    * Classes and Namespaces support
        * + inheritance, mixing
    * Promises, XHR requests (AJAX)
    * Data binding
    * Controls fitting in the UI model
    * Animations









