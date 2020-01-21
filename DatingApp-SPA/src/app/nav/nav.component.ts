import { Component, OnInit } from "@angular/core";
import { AuthService } from "../_services/auth.service";
import { Router } from '@angular/router';

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"]
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(private authService: AuthService, private router: Router) { }
  ngOnInit() { }
  loggedIn() {
    return this.authService.loggedIn();
    console.log(this.model);
  }
  logOut() {
    return this.authService.logOut();
    console.log(this.model);
  }
}
