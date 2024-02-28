import Axios from "axios";

export async function fetchPersonNames(
  apiUrl: string,
  onNamesFetched: (names: string[]) => void
): Promise<string[]> {
  const url = apiUrl + "/persons/names/";
  const { data } = await Axios.get(url);
  const names = data;
  console.log("Fetched person names (from " + url + "):\r\n", names);
  onNamesFetched(names);
  return names;
}

export async function fetchPersonDetails(
  apiUrl: string,
  name: string,
  onDetailsFetched: (details: any) => void
): Promise<any> {
  const url = apiUrl + "/persons/" + name + "/details/";
  // DON'T DO THAT (concatenating strings coming from the UI; I have to fix this :-| )
  const { data } = await Axios.get(url);
  let details = data;
  details.imageUrl = apiUrl + details.imageUrl;
  console.log("Fetched person details (from " + url + "):\r\n", details);
  onDetailsFetched(details);
  return details;
}
