import { Component, OnInit, Input, EventEmitter, Output } from "@angular/core";
import { AuthService } from "../_services/auth.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  constructor(
    private authService: AuthService,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {}
  register() {
    this.authService.register(this.model).subscribe(
      () => {
        this.alertifyService.success("regestered account successfully");
      },
      error => {
        this.alertifyService.error(
          JSON.stringify(error.errors)
            .replace("{", "")
            .replace("}", "")
        );
      }
    );
  }
  cancel() {
    this.cancelRegister.emit(false);
  }
}
