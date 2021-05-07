import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceTaskService } from '../Task/ServiceTask.service';
import { Task } from '../Task/Task'
import { ServiceUserService } from '../User/ServiceUser.service';
import { User } from '../User/User';
import { ServiceProjectService } from '../Project/ServiceProject.service';
import { Project } from '../Project/Project'
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-createtask',
  templateUrl: './CreateTask.component.html',
  styleUrls: []
})
export class CreateTaskComponent implements OnInit {
  public listStatus = [] as any;
  public projects : Project[] = [];
  public users : User[] = [];

  constructor(public taskService:ServiceTaskService,public userService:ServiceUserService,public projectService:ServiceProjectService,private router:Router) {
    this.listStatus=[{id:0,statusname : "New"},
    {id:1,statusname : "InProgress"},
    {id:2,statusname : "Testing"},
    {id:3,statusname : "Completed"},];  
  }

  ngOnInit() {
    if(!localStorage.getItem('token'))
    {
      this.router.navigate(['Login']);
    }
    this.projectService.getAll().subscribe((data: Project[])=>{
      console.log(data);
      this.projects = data;
    });

    this.userService.getAll().subscribe((data: User[])=>{
      console.log(data);
      this.users = data;
    });
  }
  onAddTask(taskdata : NgForm)
  {
    console.log(taskdata.value);

    var task=taskdata.value as Task;
    task.projectID=parseInt(task.projectID.toString());
    task.assignedToUserID=parseInt(task.assignedToUserID.toString());
    task.status=0;
    task.createdOn=new Date();

    console.log(task);
      this.taskService.create(task).subscribe(res =>{ 
        console.log(res);
        console.log('Task created!')
      this.router.navigate(['Task']);
    });   
  }
}

