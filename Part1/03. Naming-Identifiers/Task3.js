function clickOnTheButton(event, arguments) {
    var myWindow = window,
        browser = myWindow.navigator.appCodeName,
        isBrowserMozilla = browser == "Mozilla";

    if (isBrowserMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}