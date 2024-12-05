import * as calculator from "./calc.js";

function sortNums(arr){
    arr.sort((a,b) => b - a); 

    // (a,b) => a - b  :Sort in ascending order
    // (a,b) => b - a  :Sort in descending order
}


function test(){
    // Arrange
    let nums = [3, 21, 8, -2]
    let expected = "[21,8,3,-2]"

    // Act
    sortNums(nums)
    let result = JSON.stringify(nums)

    // Assert
    if (result !== expected ){
        console.error('Function sortNums not working!')
    } else {
        console.log('Function sortNums work properly.');
    }
}

function print(){
    console.log(calculator.sumNumbers(3,7))
    console.log(calculator.subtractNumbers(10, 5))
    console.log(calculator.name)
}

print()


