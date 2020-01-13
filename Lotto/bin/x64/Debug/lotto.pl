remove_at(X,[X|Xs],1,Xs).
remove_at(X,[Y|Xs],K,[Y|Ys]) :- K > 1,
   K1 is K - 1, remove_at(X,Xs,K1,Ys).

range(I,I,[I]).
range(I,K,[I|L]) :- I < K, I1 is I + 1, range(I1,K,L).

rnd_select(_,0,[]).
rnd_select(Xs,N,[X|Zs]) :- N > 0,
    length(Xs,L),
    I is random(L) + 1,
    remove_at(X,Xs,I,Ys),
    N1 is N - 1,
    rnd_select(Ys,N1,Zs).

lotto(N,M,L) :- range(1,M,R), rnd_select(R,N,L).

findnum(X,[X|Tail],Ispis):-
        Ispis = 'Pronaden'.
findnum(X,[],Ispis):-
        Ispis = 'Nije pronaden'.
findnum(X,[Y|Tail],Ispis):-
        findnum(X,Tail,Ispis).
