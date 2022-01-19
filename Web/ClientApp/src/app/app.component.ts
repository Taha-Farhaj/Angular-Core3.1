import { Component, OnInit } from '@angular/core';
import { get } from 'jquery';
import { AuthenticationService } from './Auth/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'CRM';
  loading = true;

  constructor(private authenticationService: AuthenticationService) {

  }
  ngOnInit() {
    get("assets/js/custom.min.js", () => {
    });
    if (this.authenticationService.currentUserValue == null) {
      this.loading = false;
    }
  }
}

