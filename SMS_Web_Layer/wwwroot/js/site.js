if ($("a.confirmDeletion")) {
	$("a.confirmDeletion").click(() => {
		if (!confirm("Confirm Deletion")) {
			return false;
		}
	});
}