redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51O7rQuDzA4AuxPihnKl733kPjTBAGHjMy1cKWH4AqQJCXasIq4uMQFh2f8WJ4K3Ztzi5xwkD4e9xTwhBH7pjQPPM00a9bZjnp4");
    stripe.redirectToCheckout({ sessionId: sessionId });
}