import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceTaskService } from '../Task/ServiceTask.service';
import { Task } from '../Task/Task'
@Component({
  selector: 'app-hometask',
  templateUrl: './HomeTask.component.html',
  styleUrls: []
})
export class HomeTaskComponent implements OnInit {
  public tasks : Task[] = [];
  constructor(private taskService:ServiceTaskService,private router:Router) {
    }

  ngOnInit() {
    if(!localStorage.getItem('token'))
    {
      this.router.navigate(['Login']);
    }
    this.taskService.getAll().subscribe((data: Task[])=>{
      console.log(data);
      this.tasks = data;
    })  
  }

  onSelected(tasks :Task)
  {
    this.taskService.updateTaskCollection = tasks;
    this.router.navigate(['TaskUpdate']);
  }
  

}