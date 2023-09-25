import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CourseViewModel } from 'src/viewmodel/CourseViewModel';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  public basePath: string = 'https://localhost:7180/api';

  constructor(private httpClient: HttpClient) { 
  }

  GetAllCourses() : Observable<CourseViewModel[]> {
    return this.httpClient.get<CourseViewModel[]>(`${this.basePath}/Course/GetAllCourses`);
  }
}
