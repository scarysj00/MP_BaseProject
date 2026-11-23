mergeInto(LibraryManager.library, 
{
    Browser_Alert: function (ptr) 
    {
        alert(UTF8ToString(ptr));
    },
    Browser_CopyToClipboard: function (ptr)
    {
        navigator.clipboard.writeText(UTF8ToString(ptr));
    },
    Browser_Vibrate: function (ms)
    {
        if (navigator.vibrate) navigator.vibrate(ms);
    }
});