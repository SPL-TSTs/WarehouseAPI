import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-electric-meter',
  templateUrl: './electric-meter.component.html',
  styleUrls: ['./electric-meter.component.css']
})
export class ElectricMeterComponent {
  electricMeterForm = this.fb.group({
    SerialNumber: ['', Validators.required],
    FirmwareVersion: [''],
    State: ['']
  });

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  
  onSubmit() {
    const url = 'https://localhost:44354/ElectricMeter';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(url, this.electricMeterForm.value, httpOptions).subscribe((response: any) => {
      this.electricMeterForm.reset();
    });
  }
}


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
