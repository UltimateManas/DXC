(function fibonacci(len) {

    var result = [];
    let a = 0,
        b = 1,
        c = 0;

    result.push(a);
    result.push(b);

    for (let i = 2; i < len; i++) {
        c = a + b;
        a = b;
        b = c;
        result.push(c);
    }
    console.log(result.join(','));
})(8);