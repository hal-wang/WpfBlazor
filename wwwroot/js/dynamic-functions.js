!(() => {
    window.H = {
        Functions: {},
        AddFunction: function (id, code) {
            window.H.Functions[id] = eval(code);
        }
    }
})()