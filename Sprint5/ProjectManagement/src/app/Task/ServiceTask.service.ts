import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Task } from '../Task/Task'
import { CommonServiceService } from '../CommonService.service'

@Injectable({
  providedIn: 'root'
})
export class ServiceTaskService extends CommonServiceService<Task>{

  updateTaskCollection!:Task;
  
  constructor(protected http :HttpClient) {
    super(http,'Tasks');
   }
}
