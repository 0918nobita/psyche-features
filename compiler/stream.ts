import Rx = require('rxjs');

// ひとつの値が流れるだけの Cold Observable を作る
const streamA$ = Rx.of(42);

const streamB$ = Rx.from([10, 20, 30]);

Rx.combineLatest(streamA$, streamB$)
  .subscribe((v: [number, number]) => console.log('next', v));
