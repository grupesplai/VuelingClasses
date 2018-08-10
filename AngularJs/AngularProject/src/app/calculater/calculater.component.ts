import { Component, OnInit } from '@angular/core';
import {Calculator} from './calculator';
@Component({
  selector: 'app-calculater',
  templateUrl: './calculater.component.html',
  styleUrls: ['./calculater.component.css']
})
export class CalculaterComponent implements OnInit {

  public field1 : number;
  public field2 : number;
  public result : number;
  public cal: Calculator;

  sum(){
    return this.result = this.cal.sum(this.field1, this.field2);
  }
  sustract(){
    return this.result = this.cal.sustract(this.field1, this.field2);
  }
  multiply(){
    return this.result = this.cal.multiply(this.field1, this.field2);
  }
  divide(){
    return this.result = this.cal.divide(this.field1, this.field2);
  }

  constructor() { 
    this.cal = new Calculator();
  }

  ngOnInit() {
  }
}
