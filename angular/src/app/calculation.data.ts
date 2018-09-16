import {MathOperations} from './math.operations';

export class CalculationData {
  operand1: number;
  operand2: number;
  mathOperation: string;

  constructor() {
    this.mathOperation = MathOperations[0];
  }
}
