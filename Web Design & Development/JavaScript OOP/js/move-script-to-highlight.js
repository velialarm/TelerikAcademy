var codeElement = document.getElementById('taskJavaScriptCode');
var codeHTML = codeElement.innerHTML;
var mod = document.querySelector("#highlightCodeID");
mod.appendChild(document.createElement('pre'));
var preMod = document.querySelector("#highlightCodeID pre");
preMod.appendChild(document.createElement('code'));
var codeMod = document.querySelector("#highlightCodeID pre code");
codeMod.appendChild(document.createElement('div')).textContent = 'Java Script Sourse Code';
codeMod.appendChild(document.createElement('div')).textContent = codeHTML;