import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemoNouveauComponent } from './memo-nouveau.component';

describe('MemoNouveauComponent', () => {
  let component: MemoNouveauComponent;
  let fixture: ComponentFixture<MemoNouveauComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MemoNouveauComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MemoNouveauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
