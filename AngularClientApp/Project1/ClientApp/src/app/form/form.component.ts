import { Component } from '@angular/core';
export type EditorType = 'watermeter' | 'electricmeter' | 'gateway';

@Component({
  selector: 'app-counter-component',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class CounterComponent {
  editor: EditorType = 'gateway';

  get showWaterForm() {
    return this.editor === 'watermeter';
  }

  get showElectricForm() {
    return this.editor === 'electricmeter';
  }

  get showGatewayForm() {
    return this.editor === 'gateway';
  }

  toggleEditor(type: EditorType) {
    this.editor = type;
  }
}
