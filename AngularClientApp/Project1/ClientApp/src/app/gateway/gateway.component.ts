import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-gateway',
  templateUrl: './gateway.component.html',
  styleUrls: ['./gateway.component.css']
})
export class GatewayComponent {
  gatewayForm = this.fb.group({
    SerialNumber: ['', Validators.required],
    FirmwareVersion: [''],
    State: [''],
    IP: [''],
    Port: ['']
  });

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  
  onSubmit() {
    const url = 'https://localhost:44354/Gateway';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(url, this.gatewayForm.value, httpOptions).subscribe((response: any) => {
      this.gatewayForm.reset();
    });
  }
}


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
