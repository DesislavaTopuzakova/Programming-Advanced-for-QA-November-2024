import { assert, expect } from 'chai';
import * as calculator from './calc.js';

describe("Test calculator functionalitis.", function(){
    it("Test_SumWorkProperly.", function(){
        // Arrange
        let a = 5;
        let b = 10;
        let expected = 15;

        // Act
        let result = calculator.sumNumbers(a, b)

        // Assert
        assert.equal(result, expected)
        expect(result).to.equal(expected)
    });

    it("Test_CheckFirstArgumetnAreNumber", function(){
        // Arrange
        let a = 'x';
        let b = 10;

        // Act & Assert
        expect(() => calculator.sumNumbers(a,b).to.throw());
    })

    it("Test_CheckSecondArgumetnAreNumber", function(){
        // Arrange
        let a = 5;
        let b = 'n';

        // Act & Assert
        expect(() => calculator.sumNumbers(a,b).to.throw());
    })

    it("Test_CheckSubtractWorkProperly", function(){
         // Arrange
         let a = 5;
         let b = 10;
         let expected = -5;

         // Act
         let result = calculator.subtractNumbers(a,b)

         // Assert
         expect(result).to.equal(expected)
    })
});