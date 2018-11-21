import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
  name: 'formatTime'
})
export class FormatTimePipe implements PipeTransform {


  // seconds = Math.floor(milliseconds / 1000);
  // minute = Math.floor(seconds / 60);
  // seconds = seconds % 60;
  // hour = Math.floor(minute / 60);
  // minute = minute % 60;
  // day = Math.floor(hour / 24);
  // hour = hour % 24;

  transform(value: number): string {
    // const s: number = Math.floor(value / 1000);
    // let m: number = Math.floor(s / 60);
    // let h: number = Math.floor(m / 60);
    // m = m % 60;
    // const d: number = Math.floor(h / 24);
    // h = h % 24;

    // const hours: number = Math.floor(value / 3600);
    // const days: number = Math.floor(h / 24);
    // const minutes: number = Math.floor((value % 3600) / 60);

    let total_hours, total_minutes, total_seconds;

    total_seconds = (Math.floor(value / 1000));
    total_minutes = (Math.floor(total_seconds / 60));
    total_hours = (Math.floor(total_minutes / 60));

    const days: number = (Math.floor(total_hours / 24));
    const seconds: number = (total_seconds % 60);
    // const minutes: number = (total_minutes % 60);
    const minutes: number = Math.floor((value % 3600) / 60);
   // const hours: number = Math.floor(value / 3600);
     const hours: number = (total_hours % 24);
    return ('00' + days).slice(-2) + ':' + ('00' + hours).slice(-2) + ':' +
      ('00' + minutes).slice(-2) + ':' + ('00' + Math.floor(value - minutes * 60 )).slice(-2);
  }

}
