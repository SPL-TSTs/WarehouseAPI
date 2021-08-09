import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-water-meter',
  templateUrl: './water-meter.component.html',
  styleUrls: ['./water-meter.component.css']
})
export class WaterMeterComponent {
  waterMeterForm = this.fb.group({
    SerialNumber: ['', Validators.required],
    FirmwareVersion: [''],
    State: ['']
  });

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  
  onSubmit() {
    const url = 'https://localhost:44354/WaterMeter';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(url, this.waterMeterForm.value, httpOptions).subscribe((response: any) => {
      this.waterMeterForm.reset();
    });
  }
}


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
