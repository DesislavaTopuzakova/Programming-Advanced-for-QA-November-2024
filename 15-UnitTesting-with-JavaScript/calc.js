function sumNumbers(a,b){
    if (typeof a != 'number' || typeof b != 'number'){
        throw new TypeError('This function works only with numbers')
    }

    return a + b;
}
 
function subtractNumbers(a,b){
    return a - b;
}

let name = "Diyan"

export{
    sumNumbers,
    subtractNumbers,
    name
}