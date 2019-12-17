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

// Promise を渡した場合、それを解決して得られた値を流す Cold Observable を作る
// Promise が解決された後に subscribe しても値は流れる
const timer = Rx.from(new Promise<string>(resolve => {
  setTimeout(() => resolve("2秒経過"), 2000);
}));

timer.subscribe(v => console.log('Log(timer):', v));

/*
setTimeout(() => {
  timer.subscribe(v => console.log('Log(timer2):', v));
}, 4000);
*/

Rx.combineLatest(streamA$, streamB$)
  .subscribe((v: [number, number]) => console.log('next', v));
