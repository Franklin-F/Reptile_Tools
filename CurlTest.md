软件测试时用到的CURL

```bash
curl 'http://101.43.202.196:8080/login' \
  -H 'Accept: application/json, text/plain, */*' \
  -H 'Accept-Language: zh-CN,zh;q=0.9,en;q=0.8' \
  -H 'Cache-Control: no-cache' \
  -H 'Content-Type: application/x-www-form-urlencoded' \
  -H 'Cookie: SESSION=72c990d3-a4e8-4b31-a5b2-d72a9de0acbb; XSRF-TOKEN=454b8c02-ff10-4979-a224-8590b49992db' \
  -H 'Origin: http://101.43.202.196:8080' \
  -H 'Pragma: no-cache' \
  -H 'Proxy-Connection: keep-alive' \
  -H 'Referer: http://101.43.202.196:8090/console/login?redirect_uri=http://101.43.202.196:8090/console/' \
  -H 'User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36' \
  -H 'X-XSRF-TOKEN: 454b8c02-ff10-4979-a224-8590b49992db' \
  --data-raw '_csrf=454b8c02-ff10-4979-a224-8590b49992db&username=admin&password=hEOT8aC9KICCxInshQQ5ESRGli5EMKeEbPK8Sj%2B7SLHMpC5kzGdyB%2BVdMQ2GPKXiArBVenreR52f5QlpTNuqI5572WA4V4kkxbiSfLLdN5uGAzHxbeo74%2B%2B9CsyqAhgDYfwjdDrln4M%2F2Vis00XfXXnQiSKE2Op80MXum9kqmWFf7DdJYfiREj4yf%2BRBmo9dSMUk9Z8VBg6JC%2B6A6XevShX5r2ZT3bZP84EJgQzZSbuklGl2fq%2Few8C1%2BaIVaQh50tlshpKQC6imDOwHDmzKC5H%2BfWn2KjH7XIFw7ocyLTbJDmWNET10kR9iEAxaHX76yn%2FGuHMOpBCn4UJKEuhBFg%3D%3D' \
  --insecure
```

```bash
curl 'https://mon.zijieapi.com/monitor_browser/collect/batch/?biz_id=douyin_web' \
  -H 'authority: mon.zijieapi.com' \
  -H 'accept: */*' \
  -H 'accept-language: zh-CN,zh;q=0.9,en;q=0.8' \
  -H 'cache-control: no-cache' \
  -H 'content-type: application/json' \
  -H 'origin: https://www.douyin.com' \
  -H 'pragma: no-cache' \
  -H 'referer: https://www.douyin.com/' \
  -H 'sec-ch-ua: "Chromium";v="122", "Not(A:Brand";v="24", "Google Chrome";v="122"' \
  -H 'sec-ch-ua-mobile: ?0' \
  -H 'sec-ch-ua-platform: "Windows"' \
  -H 'sec-fetch-dest: empty' \
  -H 'sec-fetch-mode: cors' \
  -H 'sec-fetch-site: cross-site' \
  -H 'user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36' \
  --data-raw '{"ev_type":"batch","list":[{"ev_type":"custom","payload":{"content":"ws idle too long, fallback to http","type":"log","level":"warn","metrics":{},"categories":{"0":"ws idle too long, fallback to http"}},"common":{"bid":"douyin_web","user_id":"7321262738516493859","device_id":"b0d1f720-bbc6-4e3b-be2a-834482d6aa3e","session_id":"041fe81d-9ec2-4557-9f15-d0a57bbfd24f","release":"1.0.4.7919","env":"production","url":"https://www.douyin.com/?recommend=1","timestamp":1715095588016,"sdk_version":"1.12.6","sdk_name":"SDK_SLARDAR_WEB","pid":"/","view_id":"/_1715095086375","context":{},"network_type":"4g","sample_rate":1}}]}'
```

```bash
curl 'https://api.twitter.com/1.1/account/settings.json?include_ext_sharing_audiospaces_listening_data_with_followers=true&include_mention_filter=true&include_nsfw_user_flag=true&include_nsfw_admin_flag=true&include_ranked_timeline=true&include_alt_text_compose=true&ext=ssoConnections&include_country_code=true&include_ext_dm_nsfw_media_filter=true' \
  -H 'authority: api.twitter.com' \
  -H 'accept: */*' \
  -H 'accept-language: zh-CN,zh;q=0.9,en;q=0.8' \
  -H 'authorization: Bearer AAAAAAAAAAAAAAAAAAAAANRILgAAAAAAnNwIzUejRCOuH5E6I8xnZz4puTs%3D1Zv7ttfk8LF81IUq16cHjhLTvJu4FA33AGWWjCpTnA' \
  -H 'cache-control: no-cache' \
  -H 'cookie: guest_id_marketing=v1%3A170312707178523683; guest_id_ads=v1%3A170312707178523683; guest_id=v1%3A170312707178523683; _ga=GA1.2.582437989.1703328813; kdt=HT54mzSnaHN5ZqFq0o803VzfyA9IW0OO5nFPmPJb; auth_token=c95b4461a1376ec90895c162d7514483ac2c520c; ct0=6abe6cee8588029122002c192091f2a602dd696b9a23a109e3ef68a4e38acf7a3d93ee9587a1ab089f4f0d88753d5dc63393e39341f47986adca2e027d768dadcb9afd9791a15e238207fe0cf04b4cc1; twid=u%3D1596700166009933824; external_referer=padhuUp37zjgzgv1mFWxJ12Ozwit7owX|0|8e8t2xd8A2w%3D; _gid=GA1.2.560577386.1715075228; personalization_id="v1_v0CiOggLiad9itqP/ErL5w=="' \
  -H 'origin: https://twitter.com' \
  -H 'pragma: no-cache' \
  -H 'referer: https://twitter.com/' \
  -H 'sec-ch-ua: "Chromium";v="122", "Not(A:Brand";v="24", "Google Chrome";v="122"' \
  -H 'sec-ch-ua-mobile: ?0' \
  -H 'sec-ch-ua-platform: "Windows"' \
  -H 'sec-fetch-dest: empty' \
  -H 'sec-fetch-mode: cors' \
  -H 'sec-fetch-site: same-site' \
  -H 'user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36' \
  -H 'x-client-transaction-id: CezNzMW2P2hFmI2DavosXBzWOB1cQH6STy2AYdFfhsXigZez/8akeR5k+lrZAIZLvN/t4wiKOfKxMlpP/GMKmkwEOc+BCg' \
  -H 'x-csrf-token: 6abe6cee8588029122002c192091f2a602dd696b9a23a109e3ef68a4e38acf7a3d93ee9587a1ab089f4f0d88753d5dc63393e39341f47986adca2e027d768dadcb9afd9791a15e238207fe0cf04b4cc1' \
  -H 'x-twitter-active-user: yes' \
  -H 'x-twitter-auth-type: OAuth2Session' \
  -H 'x-twitter-client-language: zh-cn'
```

```bash
curl 'https://mcs.zijieapi.com/list' \
  -H 'authority: mcs.zijieapi.com' \
  -H 'accept: */*' \
  -H 'accept-language: zh-CN,zh;q=0.9,en;q=0.8' \
  -H 'cache-control: no-cache' \
  -H 'content-type: application/json; charset=UTF-8' \
  -H 'origin: https://www.douyin.com' \
  -H 'pragma: no-cache' \
  -H 'referer: https://www.douyin.com/' \
  -H 'sec-ch-ua: "Chromium";v="122", "Not(A:Brand";v="24", "Google Chrome";v="122"' \
  -H 'sec-ch-ua-mobile: ?0' \
  -H 'sec-ch-ua-platform: "Windows"' \
  -H 'sec-fetch-dest: empty' \
  -H 'sec-fetch-mode: cors' \
  -H 'sec-fetch-site: cross-site' \
  -H 'user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36' \
  --data-raw '[{"events":[{"event":"web_bd_ticket_guard_consumer_response","params":"{\"_staging_flag\":0,\"sdk_version\":\"3.0.18\",\"self_platform\":\"web\",\"params_for_special\":\"uc_login\",\"logid\":\"202405072318082D1CA3981765E92EEA18\",\"path\":\"/passport/token/beat/web/\",\"ticket_guard_version\":2,\"ticket_guard_iteration_version\":1,\"request_with_csr\":0,\"request_with_cert\":0,\"request_with_client_data\":1,\"error_code\":\"-99\",\"login_status\":\"1\",\"sign_version\":\"0\",\"cookie_status\":\"0\",\"data_from\":\"0\",\"cookie_crypt\":\"1\",\"iframe_status\":\"1\",\"match_md5_local\":\"1\",\"match_md5_iframe\":\"1\",\"is_pubkey_ts_sign\":\"1\",\"iframe_connection\":\"1\",\"iframe_retrycount\":\"0\",\"lost\":\"0\",\"init_match\":\"1\",\"is_new_cert\":\"1\",\"hostname\":\"www.douyin.com\",\"cookie_domain\":\"3\",\"event_index\":1715095204263}","local_time_ms":1715095090326,"is_bav":0,"session_id":"81e60b97-29c0-458b-9092-b23e24dfc636"},{"event":"web_bd_ticket_guard_consumer_response","params":"{\"_staging_flag\":0,\"sdk_version\":\"3.0.18\",\"self_platform\":\"web\",\"params_for_special\":\"uc_login\",\"logid\":\"20240507231808B4FC39E05D944F2657ED\",\"path\":\"/passport/token/beat/web/\",\"ticket_guard_version\":2,\"ticket_guard_iteration_version\":1,\"request_with_csr\":0,\"request_with_cert\":0,\"request_with_client_data\":1,\"error_code\":\"-99\",\"login_status\":\"1\",\"sign_version\":\"0\",\"cookie_status\":\"0\",\"data_from\":\"0\",\"cookie_crypt\":\"1\",\"iframe_status\":\"1\",\"match_md5_local\":\"1\",\"match_md5_iframe\":\"1\",\"is_pubkey_ts_sign\":\"1\",\"iframe_connection\":\"1\",\"iframe_retrycount\":\"0\",\"lost\":\"0\",\"init_match\":\"1\",\"is_new_cert\":\"1\",\"hostname\":\"www.douyin.com\",\"cookie_domain\":\"3\",\"event_index\":1715095204262}","local_time_ms":1715095090325,"is_bav":0,"session_id":"81e60b97-29c0-458b-9092-b23e24dfc636"}],"user":{"user_unique_id":"7321262738516493859","user_id":"7321262738516493859","device_id":"7321262738516493859","web_id":"7321262749102048808"},"header":{"app_id":6383,"os_name":"windows","os_version":"10","device_model":"Windows NT 10.0","language":"zh-CN","platform":"web","sdk_version":"5.0.47","sdk_lib":"js","timezone":8,"tz_offset":-28800,"resolution":"1536x865","browser":"Chrome","browser_version":"122.0.0.0","referrer":"https://www.douyin.com/","referrer_host":"www.douyin.com","width":1536,"height":865,"screen_width":1536,"screen_height":865,"tracer_data":"{\"$utm_from_url\":1}","custom":"{}"},"local_time":1715095090,"verbose":1}]'
```

