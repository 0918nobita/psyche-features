import Rx = require('rxjs');

// ひとつの値が流れるだけの Cold Observable を作る
const streamA$ = Rx.of(42);

streamA$.subscribe(
  x => console.log('next:', x),   // onNext: 値が流れてくる
  err => console.error(err),      // onError: ストリームでのエラー
  () => console.log('completed')  // onComplete: ストリームの「終了」
);

// 配列を渡した場合、先頭から順に要素を流す Cold Observable を作る
const streamB$ = Rx.from([10, 20, 30]);

Rx.combineLatest(streamA$, streamB$)
  .subscribe((v: [number, number]) => console.log('next', v));
