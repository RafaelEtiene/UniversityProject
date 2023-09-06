import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StudentViewModel } from '../viewmodel/StudentViewModel';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  public basePath: string = 'https://localhost:7180/api';

  constructor(private httpClient: HttpClient) { 
  }
  
  public GetAllStudents() : Observable<StudentViewModel[]> {
    return this.httpClient.get<StudentViewModel[]>(`${this.basePath}/Student/GetAllStudents`)
  }
}
