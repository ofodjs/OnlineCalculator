import {Component, OnInit, NgModule} from '@angular/core';
import {ApiService} from '../api.service';
import {OperationResult} from '../operationresult';
import {MathOperations} from '../math.operations';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})

export class CalculatorComponent implements OnInit {

  operand1: number;
  operand2: number;
  selectedOperation: string;
  mathOperations = MathOperations;
  operationResult: OperationResult;

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    if(this.mathOperations && this.mathOperations.length > 0){
      this.selectedOperation = this.mathOperations[0];
    }
  }

  recalculate() {
    this.apiService
      .calculate(this.operand1, this.operand2, this.selectedOperation)
      .subscribe((res) => this.operationResult = res);
  }

}
