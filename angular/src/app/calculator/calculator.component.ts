import {Component, OnInit, NgModule} from '@angular/core';
import {ApiService} from '../api.service';
import {OperationResult} from '../operationresult';
import {MathOperations} from '../math.operations';
import {CalculationData} from '../calculation.data';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})

export class CalculatorComponent implements OnInit {

  model = new CalculationData();
  mathOperations = MathOperations;
  operationResult: OperationResult;

  constructor(private apiService: ApiService) {}

  ngOnInit() {
  }

  recalculate() {
    this.apiService
      .calculate(this.model)
      .subscribe((res) => this.operationResult = res);
  }

}
