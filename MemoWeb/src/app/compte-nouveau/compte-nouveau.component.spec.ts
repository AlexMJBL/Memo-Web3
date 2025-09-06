import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompteNouveauComponent } from './compte-nouveau.component';

describe('CompteNouveauComponent', () => {
  let component: CompteNouveauComponent;
  let fixture: ComponentFixture<CompteNouveauComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompteNouveauComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompteNouveauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
