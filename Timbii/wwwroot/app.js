function scrollToElement(id) {
    var content = document.getElementById(id);
    console.log(content);

    var show = setTimeout(checkClass(content, "show"), 1000);

    if (show) {
        content.scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });
        console.log("scrolling");

    } else {
        return;
    }
}

function checkClass(elem, className) {
    if (elem.classList.contains(className)) {
        return true;
    } else {
        return false;
    }
}

function handleEnter(e) {
    // Check if the pressed key is Enter (keyCode 13 or key 'Enter')
    if (e.keyCode === 13 || e.key === 'Enter') {
        // Prevent the default behavior of Enter (creating a new line)
        e.preventDefault();
        // Submit the form
        document.getElementById('').submit();
    }
}

function scrollToLastMessage(ref, smoothScroll) {
    //var elem = document.querySelector(".message-container:last-of-type");
    //if (elem != null) {
    //    //last.scrollTop({ behavior: "smooth", block: "end", inline: "nearest" });

    //    var rect = elem.getBoundingClientRect();
    //    window.scrollTo(0, rect);
    //}

    var last = document.querySelector(".message-container:last-of-type");
    if (last != null) {
        if (smoothScroll) {
            last.scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });
        } else {
            last.scrollIntoView({ behavior: "instant", block: "end", inline: "nearest" });
            ref.invokeMethodAsync("ShowMessages");
        }
    }
}

function copyToClipboard(msgId) {
    var id = msgId + "-text";
    var html = document.getElementById(id).innerHTML;
    console.log('copying', html);
    var text = html.toString().replace(/<!--!-->/g, '') // get rid of blazor debug comments
    navigator.clipboard.writeText(text);
}

//if (ChildContent != null) {
//    await Js.InvokeAsync < string > ("copyToClipboard", CodeRef);
//    isCopied = true;
//    StateHasChanged();
//    await Task.Delay(3000);
//    isCopied = false;
//}