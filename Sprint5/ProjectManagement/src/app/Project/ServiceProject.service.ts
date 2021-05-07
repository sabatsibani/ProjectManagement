import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Project } from '../Project/Project';
import { CommonServiceService } from 'src/app/CommonService.service';

@Injectable({
  providedIn: 'root'
})
export class ServiceProjectService extends CommonServiceService<Project>{

  updateProjectCollection! : Project;
  
  constructor(protected http :HttpClient) {
    super(http,'Project');
   }
}
