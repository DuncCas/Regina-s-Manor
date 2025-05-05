VAR allreadySaid = false
-> Buonase


===Buonase===
Buonasè

    * Maronne san gennà
    ->REAL_NEAPOLITAN
    + Sorry i don't speak neapolitan
    ->NOT_NEAPOLITAN
    * Sto facenn nu marunn cacio e maccarun  e nishuno mi deve scazza ru cazz
    ->REAL_NEAPOLITAN

=== REAL_NEAPOLITAN ===
We sfaccimm! Finalmente uno che me gapisch maro
-> END


=== NOT_NEAPOLITAN ===
{allreadySaid: 
Uà me stai a piglià per ro culo uh
-else:
Amma speaking neapolitan now soo you have to speak neapolitan yes 
}
~ allreadySaid = true
-> Buonase

