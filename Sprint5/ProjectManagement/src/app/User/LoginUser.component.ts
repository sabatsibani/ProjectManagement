import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ServiceUserService } from '../User/ServiceUser.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-loginuser',
  templateUrl: './LoginUser.component.html',
  styleUrls: []
})
export class LoginUserComponent implements OnInit {
  username! : string; 
  welcomeuser! :string;

  constructor(private userService:ServiceUserService,
    private router:Router) { }
    
   ngOnInit(): void {
  }

    onLogin(loginForm : NgForm)
    {        
      console.log(loginForm.value);

      this.userService.login(loginForm.value).subscribe(
         res=>{this.username =res.email; this.welcomeuser=res.firstname +" "+res.lastname;      
         if(this.username != null)
         {
           localStorage.setItem('token',this.welcomeuser); 
           this.router.navigate(['Home']);
         }
        }       
      );    
    }
}
