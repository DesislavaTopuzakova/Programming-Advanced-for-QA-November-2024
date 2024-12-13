import { analyzeArray } from "../04-Array-Analyzer/arrayAnalyzer.js";
import { expect } from "chai";

describe('04.ArrayAnalyzer', () => {
    it('If input is not a array shoud terun undefined', () => {
        expect(analyzeArray('a')).to.undefined
        expect(analyzeArray(null)).to.undefined
        expect(analyzeArray(undefined)).to.undefined
    })

    it('If input is a empty array shoud terun undefined', () => {
        expect(analyzeArray([])).to.undefined
    })

    it('If input is a array with single element shoud terun properly exit', () => {
        let expectedObject = { 
            min: 42, 
            max: 42, 
            length: 1 
        }
        // Подход с който сравняваме стойноста на всяко пропърти
        expect(analyzeArray([ 42 ]).min).to.equal(expectedObject.min)
        expect(analyzeArray([ 42 ]).max).to.equal(expectedObject.max)
        expect(analyzeArray([ 42 ]).length).to.equal(expectedObject.length)

        // Подход с който да сравним директно два обекта
        expect(analyzeArray([42])).to.include(expectedObject)
    })

    it('If input is a array with equal elements shoud terun properly exit', () => {
        let expectedObject = { 
            min: 42, 
            max: 42, 
            length: 4
        }
        expect(analyzeArray([ 42, 42, 42, 42 ]).min).to.equal(expectedObject.min)
        expect(analyzeArray([ 42, 42, 42, 42 ]).max).to.equal(expectedObject.max)
        expect(analyzeArray([ 42, 42, 42, 42 ]).length).to.equal(expectedObject.length)
    })

    it('If input is a array with not equal elements shoud terun properly exit', () => {
        let expectedObject = { 
            min: -1, 
            max: 120, 
            length: 5
        }
        expect(analyzeArray([ 2, 42, -1, 120, 7 ]).min).to.equal(expectedObject.min)
        expect(analyzeArray([ 2, 42, -1, 120, 7 ]).max).to.equal(expectedObject.max)
        expect(analyzeArray([ 2, 42, -1, 120, 7 ]).length).to.equal(expectedObject.length)
    })
});