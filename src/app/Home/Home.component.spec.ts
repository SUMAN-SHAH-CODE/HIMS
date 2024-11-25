import { TestBed } from '@angular/core/testing';
import { PatientComponent } from '../Patient/Patient.Patientcomponent';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PatientComponent],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(PatientComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have the 'HIMS' title`, () => {
    const fixture = TestBed.createComponent(PatientComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('HIMS');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(PatientComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Hello, HIMS');
  });
});
